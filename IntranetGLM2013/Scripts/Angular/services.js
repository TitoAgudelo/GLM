'use strict';

/* Services */

var services = angular.module('glm.services', []);

services.service('dataService', ['$http', function ($http) {
    var urlBase = '../api/person';

    this.getPerson = function (id) {
        return $http.get(urlBase + '/' + id);
    };

    this.getItems = function () {
        var urlItems = '../api/lunchItem';
        return $http.get(urlItems);
    };

    this.saveItem = function (item) {
        var urlSaveItem = '../api/lunchItem';
        return $http.post(urlSaveItem, item)
    };

    this.getDates = function () {
        var urlGetDates = '../api/dailyLunch';
        var week = "week";
        return $http.post(urlGetDates + '?GetDays=' + week)
    };

    this.getDailyLunch = function (dayDate) {
        var urlDailyLunch = '../api/dailyLunch';
        return $http.post(urlGetDates + '/' + dayDate)
    };
}]);


services.factory('dataFactory', ['$http', function ($http) {
    var urlBase = '../api/person';
    var dataFactory = {};

    // get person by method get at the service in personController
    dataFactory.getPersonByEmail = function (email) {
        return $http.get(urlBase + '?email=' + email);
    };

    // get dates of week at menu lunch in the controller menuController
    dataFactory.getDates = function (date) {
        var urlGetDates = '../api/dailyLunch';
        return $http.get(urlGetDates + '?getdays=' + date)
    };

    // get week collection at weekLunch controller
    dataFactory.getWeekLunches = function (date) {
        var urlGetWeek = '../api/weeklunch';
        return $http.get(urlGetWeek + '?date=' + date)
    };

    // get day of dailyLunch by date
    dataFactory.getDailyLunch = function (dayDate) {
        var urlDailyLunch = '../api/dailyLunch';
        return $http.get(urlDailyLunch + '?date=' + dayDate)
    };

    // save lunchItem in DailyLunch
    dataFactory.addNewDailyLunch = function (daily) {
        var urlDailyLunch = '../api/dailyLunch';
        return $http.post(urlDailyLunch, daily)
    };

    // delete dailyLunch
    dataFactory.deleteDailyLunch = function (id) {
        var urlDeleteDailyLunch = '../api/dailyLunch';
        return $http.delete(urlDeleteDailyLunch + '/' + id)
    };

    // get list item by category and all items
    dataFactory.getItems = function () {
        var urlItems = '../api/lunchItem';
        return $http.get(urlItems);
    };

    // get item by Id
    dataFactory.getLunchItemById = function (id) {
        var urlItem = '../api/lunchItem';
        return $http.get(urlItem + '/' + id);
    };

    // post save a new item 
    dataFactory.saveItem = function (item) {
        var urlSaveItem = '../api/lunchItem';
        return $http.post(urlSaveItem, item)
    };

    return dataFactory;
}]);
