//Kontroler za playliste
var app = angular.module('app', ['ngRoute']);

app.config(function ($routeProvider, $locationProvider) {
    $routeProvider.when('/', { controller: "playlistCtrl", templateUrl: "FrontEnd/app/Playlist/Playlista.html" });
    $routeProvider.when('/playlist/:id', { controller: "mp3Ctrl", templateUrl: "FrontEnd/app/Mp3Files/Mp3Files.html" });
    $routeProvider.when('/playlist/:id/song/:id', { controller: "mp3fileCtrl", templateUrl: "FrontEnd/app/Mp3File/Mp3File.html" })
})


