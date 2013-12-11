var app = angular.module('glm', [
        'glm.controllers',
        'glm.filters',
        'glm.directives',
        'glm.services',
        'ngRoute',
        'ui.utils'
]);

app.config(['$routeProvider', '$locationProvider', '$sceProvider', function ($routeProvider, $locationProvider, $sceProvider) {


    $routeProvider
        .when('/', {
            templateUrl: "Content/Partials/index.html",
            controller: "menuController"
        })
        .when('/daily', {
            templateUrl: "Content/Partials/daily.html",
            controller: "menuController"
        })
        .when('/week', {
            templateUrl: "Content/Partials/dailyWeek.html",
            controller: "weekController"
        })
        .when('/lunchItems', {
            templateUrl: "Content/Partials/item.html",
            controller: "itemController"
        });
}]);