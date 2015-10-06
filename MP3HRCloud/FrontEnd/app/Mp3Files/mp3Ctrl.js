app.controller('mp3Ctrl', ['$scope', 'dataFactory', 'songInPlaylistFactory','$routeParams',
                    function ($scope, dataFactory, songInPlaylistFactory, $routeParams) {
                        $scope.playlistId = $routeParams.id;
                        $scope.loading = true;
                        $scope.addMode = false;

                        $scope.status;

                        var songUrl = 'api/Mp3Files/';
                        var songInPlaylist = 'api/SeNalaziNa/';

                        getAllSongs();

                        function getAllSongs(){
                            songInPlaylistFactory.getSongsForPlaylist($scope.playlistId)
                        .then(function (songsInPlaylist) { songInPlaylistFactory.restoreSongs(); $scope.$apply($scope.Mp3Files = JSON.parse(songsInPlaylist));  })
                        }                       

                        dohvatiGdjeSeNalaze();

                        $scope.toggleEdit = function () {
                            this.item.editMode = !this.item.editMode;
                        };

                        $scope.toggleAdd = function () {
                            $scope.addMode = !$scope.addMode;
                        };

                        function dohvatiGdjeSeNalaze() {
                            dataFactory.getAllData(songInPlaylist)
                            .success(function (data) {
                                $scope.GdjeSeNalaze = data;
                            })
                            .error(function (error) {
                                $scope.status = 'Učitavanje nije uspjelo:' + error.message;
                            })
                        }

                        //Dodavanje nove pjesme
                        $scope.add = function () {
                            $scope.loading = true;                            
                            dataFactory.addData(songUrl, this.newmp3file)
                            .success(function (data) {
                                var pjesma = {idPjesme: + data.idPjesme, idPlayliste: + $scope.playlistId };
                                dataFactory.addData(songInPlaylist, pjesma)
                                .success(function (data) {
                                    dohvatiGdjeSeNalaze();
                                    $scope.loading = false;
                                })
                                $scope.loading = false;
                                $scope.addMode = false;
                                $scope.Mp3Files.push(data);
                                $scope.newmp3file = {};
                                $scope.loading = false;
                            })
                            .error(function (data) {
                                $scope.error = "Došlo je do pogreške prilikom dodavanja " + data;
                                $scope.loading = false;
                            })
                        }

                        //Ureðivanje pjesme
                        $scope.save = function () {
                            $scope.loading = true;
                            var pjesma = this.item;
                            dataFactory.editData(songUrl + pjesma.idPjesme, pjesma)
                            .success(function (data) {
                                pjesma.editMode = false;
                                $scope.loading = false;
                            })
                            .error(function (data) {
                                $scope.error = "Problem pri spremanju" + data;
                                $scope.loading = false;
                            });
                        };

                        //Izbriši pjesmu
                        $scope.deleteSong = function () {
                            $scope.loading = true;
                            var Id = this.item.idPjesme;
                            dataFactory.deleteData(songUrl + Id)
                                .success(function (data) {
                                    $.each($scope.Mp3Files, function (i) {
                                        if ($scope.Mp3Files[i].IDPjesme == Id) { $scope.Mp3Files.splice(i, 1); return true; }
                                        getAllSongs();
                                    });                                    
                                    $scope.loading = false;

                                }).error(function (data) {
                                    $scope.error = "Pjesma nije izbrisana" + data;
                                    $scope.loading = false;
                                });
                        };                        
                }])