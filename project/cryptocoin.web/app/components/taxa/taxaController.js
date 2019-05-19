app.controller(
    'taxaController', ['$scope', '$http', '$rootScope', '$log', '$location', '$window', '$state', '$cookieStore', '$filter', 'Notification', 'taxaService',
        function ($scope, $http, $rootScope, $log, $location, $window, $state, $cookieStore, $filter, Notification, taxaService) {

            var ctrl = this;

            $scope.selectedBase = $scope.selectedTarget = $scope.recommendedfee = '';
            $scope.base = $scope.target = [];
            $scope.lsTaxas = [];
            $scope.busca = false;

            let res = taxaService.obterlistacriptomoedas()
                .then(
                    function (result) {
                        $scope.base = $scope.target = result.Retorno;

                        $scope.selectedBase = { value: $scope.base[0] };

                        $scope.selectedTarget = {
                            value: $scope.target.filter(function (item) {
                                return item.Simbolo === 'USD';
                            })[0]
                        };

                        $scope.obtertaxarecomendadabtc();
                    }).catch(function (error) {
                        Notification.error({ message: error.data.Message });
                    });

            $scope.obtertaxas = function () {
                let filtro = { Base: $scope.selectedBase.value.Simbolo, Target: $scope.selectedTarget.value.Simbolo };
                
                taxaService.obtertaxas(filtro)
                    .then(
                        function (result) {
                            if (result.Sucesso) {
                                $scope.busca = true;
                                $scope.time = result.Retorno.data;

                                $scope.lsTaxas = angular.forEach(result.Retorno.ticker.Markets, function (value) {
                                    console.log(value.Price);
                                    value = +value.Price;
                                });
                            } else {
                                Notification.error({ message: result.Exception[0].Message });
                            }

                        }).catch(function (error) {
                            Notification.error({ message: error.data.Message });
                        });
            };

            $scope.obtertaxarecomendadabtc = function () {
                console.log($scope.selectedBase.value);
                if ($scope.selectedBase.value.Simbolo === 'BTC' || $scope.selectedTarget.value.Simbolo === 'BTC') {
                    taxaService.obtertaxarecomendadabtc()
                        .then(function (result) {
                            $scope.recommendedfee = result.Retorno;
                        }).catch(function (error) { console.log('Não foi possivel obter as taxas recomendadas para BTC.'); });
                } else { $scope.recommendedfee = ''; }
            };

        }]);