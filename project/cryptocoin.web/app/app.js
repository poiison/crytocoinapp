var app = angular.module('app', ['ui.router', 'ngCookies', 'ui-notification', 'ui.select', 'ngSanitize']);

app.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/taxa');

    $stateProvider
        .state('taxa', {
            url: "/taxa",
            templateUrl: '/app/components/taxa/taxa.html',
            controller: 'taxaController'
        });

});