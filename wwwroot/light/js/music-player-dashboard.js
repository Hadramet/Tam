let now_playing1 = document.querySelector(".now-playing1");
let track_art1 = document.querySelector(".track-art1");
let track_name1 = document.querySelector(".track-name1");
let track_artist1 = document.querySelector(".track-artist1");

let playpause_btn1 = document.querySelector(".playpause-track1");
let next_btn1 = document.querySelector(".next-track1");
let prev_btn1 = document.querySelector(".prev-track1");

let seek_slider1 = document.querySelector(".seek_slider1");
let volume_slider1 = document.querySelector(".volume_slider1");
let curr_time1 = document.querySelector(".current-time1");
let total_duration1 = document.querySelector(".total-duration1");

let track_index1 = 0;
let isPlaying1 = false;
let updateTimer1;

// Create new audio element
let CurrentTrack1 = document.createElement('audio');

let track_list1 = check0;


function random_bg_color1() {

    // Get a number between 64 to 256 (for getting lighter colors)
    let red = Math.floor(Math.random() * 256) + 64;
    let green = Math.floor(Math.random() * 256) + 64;
    let blue = Math.floor(Math.random() * 256) + 64;

    // Construct a color withe the given values
    const bgColor = `rgb(${red},${green},${blue})`;

}


function loadTrack(trackIndex1) {
    clearInterval(updateTimer1);
    resetValues1();
    
    CurrentTrack1.src = track_list1[trackIndex1].LocalSource;
    CurrentTrack1.load();

    if (track_art1) {
        track_art1.style.backgroundImage = `url("images/dashboard/audio/01.png")`;
    }
    if (track_name1) {
        track_name1.textContent = track_list1[trackIndex1].Title;
    }

    if (track_artist1) {
        track_artist1.textContent = track_list1[trackIndex1].Artist;
    }
    if (now_playing1) {
        now_playing1.textContent = `PLAYING ${trackIndex1 + 1} OF ${track_list1.length}`;
    }



    updateTimer1 = setInterval(seekUpdate1, 1000);
    CurrentTrack1.addEventListener("ended", nextTrack1);
    random_bg_color1();
}

function playTrackId(id) {
    var index = 0;
    for (t in track_list1) {
        if (track_list1[t].Id != id)
            index += 1;
        else break;
    }

    loadTrack(index);
    playTrack1();
}

function resetValues1() {
    curr_time1.textContent = "00:00";
    total_duration1.textContent = "00:00";
    seek_slider1.value = 0;
}

// Load the first track in the tracklist
loadTrack(track_index1);

function playpauseTrack1() {
    if (!isPlaying1) playTrack1();
    else pauseTrack1();
}


function playTrack1() {
    CurrentTrack1.play();
    isPlaying1 = true;
    playpause_btn1.innerHTML = '<i class="fa fa-pause-circle fa-3x"></i>';
}

function pauseTrack1() {
    CurrentTrack1.pause();
    isPlaying1 = false;
    playpause_btn1.innerHTML = '<i class="fa fa-play-circle fa-3x"></i>';;
}

function nextTrack1() {
    if (track_index1 < track_list1.length - 1)
        track_index1 += 1;
    else track_index1 = 0;
    loadTrack(track_index1);
    playTrack1();
}

function prevTrack1() {
    if (track_index1 > 0)
        track_index1 -= 1;
    else track_index1 = track_list1.length;
    loadTrack(track_index1);
    playTrack1();
}

function seekTo1() {
    var seekto = CurrentTrack1.duration * (seek_slider1.value / 100);
    CurrentTrack1.currentTime = seekto;
}

function setVolume1() {
    CurrentTrack1.volume = volume_slider1.value / 100;
}

function seekUpdate1() {
    let seekPosition = 0;

    if (!isNaN(CurrentTrack1.duration)) {
        seekPosition = CurrentTrack1.currentTime * (100 / CurrentTrack1.duration);

        seek_slider1.value = seekPosition;

        let currentMinutes = Math.floor(CurrentTrack1.currentTime / 60);
        let currentSeconds = Math.floor(CurrentTrack1.currentTime - currentMinutes * 60);
        let durationMinutes = Math.floor(CurrentTrack1.duration / 60);
        let durationSeconds = Math.floor(CurrentTrack1.duration - durationMinutes * 60);

        if (currentSeconds < 10) { currentSeconds = `0${currentSeconds}`; }
        if (durationSeconds < 10) { durationSeconds = `0${durationSeconds}`; }
        if (currentMinutes < 10) { currentMinutes = `0${currentMinutes}`; }
        if (durationMinutes < 10) { durationMinutes = `0${durationMinutes}`; }

        curr_time1.textContent = currentMinutes + ":" + currentSeconds;
        total_duration1.textContent = durationMinutes + ":" + durationSeconds;
    }
}


