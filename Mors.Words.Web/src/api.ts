const commandUrl = `${__API_URL__}/api/command`
const queryUrl = `${__API_URL__}/api/query`

export async function trackedWords() {
    const response = await fetch(queryUrl, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ "$type": "Mors.Words.Data.Queries.TrackedWordsQuery, Mors.Words.Data" })
    });
    const words = await response.json();
    words.sort((a, b) => {
        const hiddenComparison = a.Hidden ? (b.Hidden ? 1 : 0) : (b.Hidden ? -1 : 0);
        if (hiddenComparison != 0) {
            return hiddenComparison;
        }
        const countComparison = b.Count - a.Count;
        return countComparison == 0 ? a.Word.localeCompare(b.Word) : countComparison;
    })
    return words.map(x => ({ word: x.Word, count: x.Count, context: x.Context == 0 ? "Meaning" : x.Context == 1 ? "Pronunciation" : "Unknown", hidden: x.Hidden }));
}

export async function trackWord({ word, pronunciation, meaning }) {
    try {
        const response = await fetch(commandUrl, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "$type": "Mors.Words.Data.Commands.TrackWordCommand, Mors.Words.Data",
                "Contexts": (meaning ? 1 : 0) | (pronunciation ? 2 : 0),
                "Word": word
            })
        });
        return response.ok;
    }
    catch (error) {
        return false;
    }
}

export async function hideWord({ word, context }) {
    try {
        const response = await fetch(commandUrl, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "$type": "Mors.Words.Data.Commands.HideWordCommand, Mors.Words.Data",
                "Context": context == "Pronunciation" ? 1 : 0,
                "Word": word
            })
        });
        return response.ok;
    }
    catch (error) {
        return false;
    }
}