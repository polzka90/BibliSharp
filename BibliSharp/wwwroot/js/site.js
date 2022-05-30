// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var speech = window.speechSynthesis;
speech.lang = "pt-BR";

var voices;
var voice;

function populateVoiceList() {
    voices = speech.getVoices();
    if (voices.length > 0) {
        voices.forEach(selectVoice);
        //voice = voices[4];
        speech.voiceURI = voice.voiceURI;
        speech.lang = voice.lang;
        speech.localService = voice.localService;
        speech.voice = voice;
    }

}

function selectVoice(item) {
    if (item.lang == "pt-BR")
        voice = item;
}

populateVoiceList();

speech.onvoiceschanged = populateVoiceList;

$("label").click(function () {
    let text = $(this).text();
    let utterThis = new SpeechSynthesisUtterance(text);
    utterThis.lang = speech.lang;
    utterThis.voice = voice;

    utterThis.pitch = 1;
    utterThis.rate = 0.5;
    speech.speak(utterThis);
});