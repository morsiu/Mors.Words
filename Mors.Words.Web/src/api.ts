const commandUrl = "http://localhost:6536/api/command"
const queryUrl = "http://localhost:6536/api/query"

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
    words.sort((a, b) => { const countComparison = b.Count - a.Count; return countComparison == 0 ? a.Word.localeCompare(b.Word) : countComparison; })
    return words.map(x => ({ word: x.Word, count: x.Count, context: x.Context == 0 ? "Meaning" : x.Context == 1 ? "Pronunciation" : "Unknown" }));
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