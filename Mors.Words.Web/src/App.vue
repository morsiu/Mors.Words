<script setup>
import * as api from "./api"
import { ref } from 'vue'

const pronunciation = ref(false);
const meaning = ref(false);
const word = ref('')
const trackedWords = ref([]);

refreshTrackedWords();

async function trackWord(newWord, meaning, pronunciation) {
  if (await api.trackWord({ word: newWord, pronunciation, meaning })) {
    word.value = "";
    await refreshTrackedWords();
  }
}

async function refreshTrackedWords() {
    const newTrackedWords = await api.trackedWords();
    trackedWords.value = newTrackedWords;
}
</script>

<template>
  <h1>Words</h1>
  <main>
    <input v-model="word" placeholder="Enter a word" type="text" />
    <button @click="trackWord(word, meaning, pronunciation)">Add</button>
    <br />
    <label for="pronunciation-input">Pronunciation:</label>
    <input id="pronunciation-input" v-model="pronunciation" type="checkbox" />
    <label for="meaning-input">Meaning:</label>
    <input id="meaning-input" v-model="meaning" type="checkbox" />
    <table>
      <thead>
        <td>Word</td>
        <td>Count</td>
        <td>Context</td>
      </thead>
      <tbody>
        <tr v-for="item in trackedWords">
          <td>{{ item.word }}</td>
          <td>{{ item.count }}</td>
          <td>{{ item.context }}</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<style scoped>

</style>
