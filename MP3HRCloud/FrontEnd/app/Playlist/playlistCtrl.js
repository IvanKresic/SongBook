
app.controller('playlistCtrl', ['$scope', 'dataFactory', 'songInPlaylistFactory',
                function ($scope, dataFactory, songInPlaylistFactory) {
                    

                    $scope.loading = true;
                    $scope.addMode = false;
                    $scope.Playliste;
                    var urlPlayliste = 'api/Playlista/';
                    dohvatiPlayliste();
                    songInPlaylistFactory.getSongsByPlaylist();

                    $scope.toggleAdd = function () {
                        $scope.addMode = !$scope.addMode;
                    };

                    $scope.toggleEditPlaylista = function () {
                        this.item.editMode = !this.item.editMode;
                    };

                    //Dohvat svih playlista
                    function dohvatiPlayliste() {
                        dataFactory.getAllData(urlPlayliste)
                        .success(function (data) {
                            $scope.Playliste = data;
                        })
                        .error(function (error) {
                            $scope.status = 'Učitavanje nije uspjelo:' + error.message;
                        })
                    }

                    //Pretraga
                    $scope.searchForPlaylist = function () {
                        $scope.Playliste = null;
                        dataFactory.getDataByName(urlPlayliste, this.searchPlaylist)
                        .success(function (data) {                            
                            $scope.Playliste = data;
                        })
                         .error(function (error) {
                             $scope.status = 'Učitavanje nije uspjelo:' + error.message;
                         })
                    }

                    //Dodavanje nove playliste
                    $scope.dodajPlaylistu = function () {
                        $scope.loading = true;
                        dataFactory.addData(urlPlayliste, this.novaplaylista)
                        .success(function (data) {
                            $scope.addMode = false;
                            $scope.Playliste.push(data);
                            $scope.novaplaylista = {};
                            $scope.loading = false;
                        })
                        .error(function (data) {
                            $scope.error = "Došlo je do pogreške prilikom dodavanja" + data;
                            $scope.loading = false;
                        })
                    }

                    //Ureðivanje playliste
                    $scope.savePlaylista = function () {
                        $scope.loading = true;
                        var playlista = this.item;
                        dataFactory.editData(urlPlayliste + playlista.idPlayliste, playlista)
                        .success(function (data) {
                            playlista.editMode = false;
                            $scope.loading = false;
                        })
                        .error(function (data) {
                            $scope.error = "Problem pri spremanju" + data;
                            $scope.loading = false;
                        });
                    };

                    //Izbriši playlistu
                    $scope.izbrisiplaylistu = function () {
                        $scope.loading = true;
                        var Id = this.item.idPlayliste;
                        dataFactory.deleteData(urlPlayliste + Id)
                            .success(function (data) {
                                $.each($scope.Playliste, function (i) {
                                    if ($scope.Playliste[i].IDPlayliste == Id) { $scope.Playliste.splice(i, 1); return true; }
                                });
                                return (dohvatiPlayliste());
                                $scope.loading = false;

                            }).error(function (data) {
                                $scope.error = "Pjesma nije izbrisana" + data;
                                $scope.loading = false;
                            });
                    };


                }])
