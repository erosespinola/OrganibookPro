var organibookControllers = angular.module('organibookControllers', []);
 
organibookControllers.controller('MainController', ['$scope', '$http', 
	function ($scope, $http) {
	}
]);

organibookControllers.controller('LoginController', ['$scope', '$http',
	function ($scope, $http) {
		$scope.invalidLogin = false;
	}
]);

organibookControllers.controller('BookListController', ['$scope', '$http',
	function ($scope, $http) {
		//sharkosaurus.com/organibook/api/book
		$http.get('api/book/').success(function (data) {
			$scope.books = data;
		});
	}
]);

organibookControllers.controller('BookDetailController', ['$scope', '$http', '$routeParams', '$location',
	function ($scope, $http, $routeParams, $location) {
		$http.get('api/book/' + $routeParams.bookId).success(function (data) {
			$scope.book = data;
		});
		
		$scope.deleteBook = function() {
			$http.delete("api/book/" + $routeParams.bookId).success(function () {
				$location.path("/books");
			});
		}
	}
]);

organibookControllers.controller('BookCaptureController', ['$scope', '$http', '$modal', '$location',
	function ($scope, $http, $modal, $location) {
		$scope.fr = 0;
		$scope.previewImage = "//placehold.it/100x100";
		
		organibookControllers.controller.prototype.$scope = $scope;
		
		$scope.receivedData = function() {
			$scope.$apply(function() {
				$scope.previewImage = $scope.fr.result;
				
				$http.post("api/isbn", '"' + $scope.fr.result + '"').success(function (data) {
					$scope.book = data;
				}).error(function (data, status) {
					var modalInstance = $modal.open({
						templateUrl: 'partials/invalid-isbn.html',
						scope: $scope
					});
				});
			});
		};
		
		$scope.submit = function () {
			console.log($scope.book);
			$http.post("api/book/", $scope.book).success(function() {
				$location.path("/books");
			}).error(function (data, status) {
				console.log("error");
				console.log(data);
				console.log(status);
			});
		};
	}
]);

// ng-change doesn't work with file inputs (angularjs bug)
organibookControllers.controller.prototype.selectFile = function (element) {
    var $scope = this.$scope;	
	var f = element.files[0];
	
	$scope.fr = new FileReader();	
	$scope.fr.onload = $scope.receivedData;
	$scope.fr.readAsDataURL(f);
};

