//var app = angular.module('app', ['ngRoute']);

app.service('songInPlaylistFactory', ['dataFactory', function (dataFactory) {
                    var songInPlaylistFactory = [];
                    var SongIsOnPlaylist = [];
                    var Songs = [];
                    var songsInPlaylist = [];
                    var playlistId;
                    var songByPlaylistUrl = 'api/SeNalaziNa/';
                    var mp3fileUrl = 'api/Mp3Files/';                    

                    this.getSongsByPlaylist = function () {
                        dataFactory.getAllData(songByPlaylistUrl)
                        .success(function (data) {
                            SongIsOnPlaylist = data;
                            return SongIsOnPlaylist;
                        });
                    }       

                    this.getSongsForPlaylist = function (id)
                    {                        
                        return new Promise(function(resolve, reject) {
                            var promises = [];
                            for (var i = 0; i < SongIsOnPlaylist.length; i++)
                            {
                                if(SongIsOnPlaylist[i].idPlayliste == id)
                                {                                 
                                    promises.push(dataFactory.getDataById(mp3fileUrl, SongIsOnPlaylist[i].idPjesme))                           
                                }                            
                            }
                            Promise.all(promises).then(function (results) {
                                for (var i = 0; i < results.length; i++)
                                {
                                    Songs.push(results[i].data);
                                }
                                songsInPlaylist = angular.toJson(Songs);                                
                                resolve(songsInPlaylist);
                            });
                        })
                    }


                    this.setSongsForView = function (songs)
                    {
                        songsInPlaylist = songs;
                    }

                    this.getSongsForView = function ()
                    {
                        alert(songsInPlaylist);
                            return songsInPlaylist;                       
                    }

                    this.restoreSongs = function()
                    {
                        Songs = [];
                    }
                }])