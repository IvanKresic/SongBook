app.controller('mp3fileCtrl', ['$scope', 'dataFactory', 'songInPlaylistFactory', '$routeParams',
                function ($scope, dataFactory, songInPlaylistFactory, $routeParams) {
                    $scope.songId = $routeParams.id;
                    var songsUrl = 'api/Mp3Files/';
                    var playlistUrl = 'api/Playlista/';
                    var songInPlaylist = 'api/SeNalaziNa/';
                    $scope.Mp3File;
                    $scope.Playlists;
                    $scope.loading = true;
                    
                    getSong();
                    getPlaylists();
                    console.log($scope.Mp3File);

                    $scope.toggleEditPjesma = function () {
                        this.Mp3File.editMode = !this.Mp3File.editMode;
                    };


                    function getSong() {
                        dataFactory.getDataById(songsUrl, $scope.songId)
                        .success(function (data) {
                            $scope.Mp3File = data;
                        })                        
                    }

                    function getPlaylists() {
                        dataFactory.getAllData(playlistUrl)
                        .success(function (data) { $scope.Playlists = data })
                    }

                    //Spremanje pjesme u playlistu
                    $scope.saveUPlaylista = function () {
                        $scope.loading = true;
                        var pjesma = {idPjesme: + this.Mp3File.idPjesme ,idPlayliste: + this.Mp3File.idPlayliste };
                        dataFactory.addData(songInPlaylist, pjesma)
                            .success(function (data) {                                
                                $scope.loading = false;
                            })
                        .error(function (data) {
                            $scope.error = "Pjesma nije dodana u playlistu" + data;
                            $scope.loading = false;
                        })

                    }
                }]);