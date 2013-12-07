"use strict";

var app = angular.module('organibook', [
  'ngRoute',
  'organibookControllers',
  'ui.bootstrap'
]);

app.config(['$routeProvider',
	function ($routeProvider) {
		$routeProvider.
			when('/', {
			templateUrl: 'partials/main.html'
		}).
			when('/books', {
			templateUrl: 'partials/book-list.html',
			controller: 'BookListController'
		}).
			when('/books/capture', {
			templateUrl: 'partials/book-capture.html',
			controller: 'BookCaptureController'
		}).
			when('/books/:bookId', {
			templateUrl: 'partials/book-detail.html',
			controller: 'BookDetailController'
		}).
		otherwise({
			redirectTo: '/'
		});
	}
]);