'use strict';

/* Controllers */

var ctrls = angular.module('glm.controllers', []);

// Controller for header nav aside elements 
ctrls.controller('navController', ['$scope', function ($scope) {
    $scope.content = false;
    $scope.options = function () {
        $scope.content = !$scope.content;
    };
}]);

// Controller for WS email for validate user and login
ctrls.controller('peopleController', ['$scope', 'dataFactory',
        function ($scope, dataFactory) {
            var provider;
            $scope.updateOptions = function () {
                var email = $scope.email;

                if (provider) {
                    $scope[provider] = false;
                }

                getPersons();

                function getPersons() {
                    dataFactory.getPersonByEmail(email)
                        .success(function (pers) {
                            if (pers && pers != "null") {
                                
                                if (pers.Provider == 1) {
                                    provider = "google";
                                }
                                else if (pers.Provider == 2) {
                                    provider = "outlook";
                                }
                                else if (pers.Provider == 3) {
                                    provider = "yahoo";
                                }

                                $scope.noUser = false;
                                $scope[provider] = true;

                            }
                            else if (pers == "null") {
                                $scope.noUser = true;
                            }
                        })
                        .error(function (error) {
                            $scope.noUser = true;
                        });
                }
            };
        }]);


ctrls.controller('itemController', ['$scope', '$rootScope', '$location','dataFactory',
    function ($scope, $rootScope, $location, dataFactory) {

        $rootScope.listDaily = false;

        $scope.setRoute = function (route) {
            $location.path(route);
        }

        // Scope to List data factory to getListItems 
        $scope.listItems = function () {
            $scope.loading = true;
            dataFactory.getItems()
                .success(function (items) {
                    if (items) {
                        var log = [];
                        $scope.contentItem = true;

                        angular.forEach(items, function (category) {
                            var CategoryString;
                            if (category.Category == 1) {
                                category.CategoryString = "Bebidas";
                            } else if (category.Category == 2) {
                                category.CategoryString = "Entradas";
                            } else if (category.Category == 3) {
                                category.CategoryString = "Proteinas";
                            } else if (category.Category == 4) {
                                category.CategoryString = "Carbohidratos";
                            } else if (category.Category == 5) {
                                category.CategoryString = "Vegetales";
                            } else if (category.Category == 6) {
                                category.CategoryString = "Postres";
                            } else if (category.Category == 7) {
                                category.CategoryString = "Especiales";
                            }
                        }, log);

                        $scope.itemList = items;
                    }
                    $scope.loading = false;
                })
                .error(function (error) {

                });
        };

        $scope.listItems();

        // Scope to close listItemsPreview
        $scope.closeWindow = function () {
            $scope.contentItem = false;
        };

        // Scope to show view of create a new item
        $scope.createNewItem = function () {
            $scope.createItemOld = false;
            $scope.createItem = true;
        };

        // Scope to hide view of create a new item 
        $scope.cancelCreateItem = function () {
            $scope.createItemOld = true;
            $scope.createItem = false;
        };

        // Scope to save a new item 
        $scope.saveItem = function (item) {
            $scope.loading = true;
            dataFactory.saveItem(item)
                .success(function (message) {
                    if (message) {
                        console.log(message);
                    }
                    $scope.loading = false;
                }).error(function (error) {
                    console.log(error);
                });
            $scope.listItems();
            $scope.cancelCreateItem();
        };
    }]);

ctrls.controller('weekController', ['$scope', '$rootScope', '$location', 'dataFactory',
    function ($scope, $rootScope, $location, dataFactory) {

        // set Url to change template and controller
        $scope.setRoute = function (route) {
            $location.path(route);
        };

        // Function to execute dinamic function
        $scope.execu = function (func, param) {
            if ($scope[func]) {
                $scope[func](param);
            }
            $scope.dates.forEach(function (date) {
                if (date.isToday)
                    date.isToday = false;
            });
            param.isToday = true;
        };

        // Scope to list dates in date 
        $scope.listDays = function (date) {
            var param = typeof date === 'object' ? date.ShortDate : date;
            $scope.loading = true;
            dataFactory.getDates(param)
                .success(function (days) {
                    if (days) {
                        var before = days.shift();
                        var after = days.pop();

                        $scope.before = before;
                        $scope.after = after;

                        var len = days.length;
                        var first = days[0].ShortDate;
                        var firstDay = moment(first, "DD/MM/YYYY").lang('es').format("D MMMM YYYY");
                        var last = days[4].ShortDate;
                        var lastDay = moment(last, "DD/MM/YYYY").lang('es').format("D MMMM YYYY");
                        $scope.weeks = [{ first: firstDay, last: lastDay }];
                        var date;
                        for (var i = 0; i < len; i++) {
                            var day = days[i].Day;
                            var onlyDay = moment(day).format('DD');
                            var momen = moment(day).format('DD/MM/YYYY');
                            if (days[i].isToday) {
                                date = days[i];
                            }

                            days[i].onlyDay = onlyDay;
                            days[i].dayString = momen;
                        }
                        if (!date) {
                            date = days[0];
                            date.isToday = true;
                        }
                        date.dayString = date.ShortDate;
                        $scope.DateDailyGlobal = date.Day;
                        $scope.getWeek(date);
                        $scope.dates = days;
                    }
                    $scope.loading = false;
                }).error(function (error) {

                });
        };

        // function to get dailyLunc by week 
        $scope.getWeek = function (date) {
            var dateString = moment(date.Day).format('YYYY/MM/DD');
            var item = [];
            dataFactory.getWeekLunches(dateString)
                .success(function (weekLunch) {
                    angular.forEach(weekLunch, function (week) {
                        var day = moment(week.LunchDate).format("dddd");
                        var objects = { date: week.LunchDate, shortDate: week.ShortDate, day: day, category: week.LunchItem.Category, id: week.LunchItem.ID, like: week.LunchItem.Like, dislike: week.LunchItem.Dislike, name: week.LunchItem.Name };
                        item.push(objects);
                    });
                    $scope.weekItems = item;
                    console.log(item);
                }).error(function () {

                });
        };

        $scope.listDays();
    }])

// Controller for menu lunch
ctrls.controller('menuController', ['$scope', '$rootScope', '$location', 'dataFactory',
    function ($scope, $rootScope, $location, dataFactory) {
        $scope.createItemOld = true;
        
        $scope.listItem = true;

        // set Url to change template and controller
        $scope.setRoute = function (route) {
            $location.path(route);
        };
        
        // Include list items
        $scope.includeItem = function () {
            $scope.listItem = false;
            $scope.contentItems = true;
            $scope.closeView = true;
        };

        // close list items content
        $scope.closeListItems = function () {
            $scope.listItem = true;
            $scope.contentItems = false;
            $scope.closeView = false;
        };

        // Active menu Ver menu, Disenar Menu, Administrar 
        $scope.isActive = function (viewLocation) {
            var active = (viewLocation === $location.path());
            return active;
        }

        // Function to execute dinamic function
        $scope.exec = function (func, param) {
            if ($scope[func]) {
                $scope[func](param);
            }
            $scope.dates.forEach(function (date) {
                if (date.isToday)
                    date.isToday = false;
            });
            param.isToday = true;
        };

        // Scope to dailyLunch data factory to get dayLunch and for by get item by Id push in listDaily
        $scope.dailyLunch = function (date) {
            var listDaily = [];
            var DateDaily = date.dayString;
            $scope.DateDailyGlobal = date.Day;
            $scope.loading = true;
            $scope.drink = { select: false };
            $scope.entrance = { select: false };
            $scope.protein = { select: false };
            $scope.carbohydrate = { select: false };
            $scope.vegetable = { select: false };
            $scope.dessert = { select: false };
            dataFactory.getDailyLunch(DateDaily)
                .success(function (daily) {
                    angular.forEach(daily, function (day) {
                        $scope.DateDailyGlobal = day.LunchDate;
                        dataFactory.getLunchItemById(day.LunchItemId)
                            .success(function (item) {
                                item.idDaily = day.ID;
                                listDaily.push(item);
                                $scope.changeIconCategory(item);
                            }).error(function (error) {

                            });
                    });
                    $scope.daily = listDaily;
                    $scope.loading = false;
                }).error(function (error) {

                });
        };

        // change icon category when the icon is in dailyLunch
        $scope.changeIconCategory = function (item) {
            var category = item.Category;

            switch (category) {
                case 1:
                    $scope.drink = { select: true };
                    break;
                case 2:
                    $scope.entrance = { select: true };
                    break;
                case 3:
                    $scope.protein = { select: true };
                    break;
                case 4:
                    $scope.carbohydrate = { select: true };
                    break;
                case 5:
                    $scope.vegetable = { select: true };
                    break;
                case 6:
                    $scope.dessert = { select: true };
                    break;
            }
        };

        // Scope to add property a item
        $scope.addDailyLunch = function (item) {
            var idItem = item.ID;
            var date = $scope.DateDailyGlobal;
            var dateShort = moment(date);
            var daily = { PublishedStatus: 1, IsEditable: true, LunchDate: date, ShortDate: dateShort, isPublished: false, LunchItemId: idItem };
            $scope.loading = true;
            dataFactory.addNewDailyLunch(daily)
                .success(function (newDaily) {
                    var dateNET = newDaily.LunchDate;
                    $scope.DateDailyGlobal = dateNET;
                    var momen = moment(dateNET).format('DD/MM/YYYY');
                    daily.dayString = momen;
                    $scope.dailyLunch(daily);
                    $scope.loading = false;
                }).error(function () {

                });
        };

        // Scope to remove property a item
        $scope.unSelectItem = function (item) {
            var idItem = item.idDaily;
            var date = $scope.DateDailyGlobal;
            var momen = moment(date).format("DD/MM/YYYY");
            $scope.loading = true;
            dataFactory.deleteDailyLunch(idItem)
                .success(function (daily) {
                    if (daily) {
                        var dateObj = { Day: daily.LunchDate, dayString: momen };
                        $scope.dailyLunch(dateObj);
                    }
                    $scope.loading = false;
                }).error(function (error) {

                });
        };

        // Scope to list dates in date 
        $scope.listDays = function (date) {
            var param = typeof date === 'object' ? date.ShortDate : date;
            $scope.loading = true;
            dataFactory.getDates(param)
                .success(function (days) {
                    if (days) {
                        var before = days.shift();
                        var after = days.pop();

                        $scope.before = before;
                        $scope.after = after;

                        var len = days.length;
                        var first = days[0].ShortDate;
                        var firstDay = moment(first, "DD/MM/YYYY").lang('es').format("D MMMM YYYY");
                        var last = days[4].ShortDate;
                        var lastDay = moment(last, "DD/MM/YYYY").lang('es').format("D MMMM YYYY");
                        $scope.weeks = [{ first: firstDay, last: lastDay }];
                        var date;
                        for (var i = 0; i < len; i++) {
                            var day = days[i].Day;
                            var onlyDay = moment(day).format('DD');
                            var momen = moment(day).format('DD/MM/YYYY');
                            if (days[i].isToday) {
                                date = days[i];
                            }

                            days[i].onlyDay = onlyDay;
                            days[i].dayString = momen;
                        }
                        if (!date) {
                            date = days[0];
                            date.isToday = true;
                        }
                        date.dayString = date.ShortDate;
                        $scope.DateDailyGlobal = date.Day;
                        $scope.dailyLunch(date);
                        $scope.dates = days;
                        $scope.dailyWeek = days;
                    }
                    $scope.loading = false;
                }).error(function (error) {

                });
        };

        $scope.listDays();
    }
]);




