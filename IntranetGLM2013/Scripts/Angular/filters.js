/* Filters */

var filters = angular.module('glm.filters', []);

filters.filter('fromNow', function () {
    return function (dateString) {
        return moment(dateString).fromNow()
    }
});