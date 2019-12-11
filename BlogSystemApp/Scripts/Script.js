var host = "https://localhost:44319/api/Values/";
var id = 0;
var myApp = angular.module("myModule", ['angularUtils.directives.dirPagination'])
    .controller("UserController", function ($scope, $http) {
        $scope.message = "";
        $scope.signUpStudent = function (user) {
            console.log(user);
            $http.post(host + "SaveUser", user).then(function (response) {
                $scope.User = "";
                $scope.message = "Account Created Succesfully";
            });

        }
    }).controller("PostController", function ($scope, $http) {
        id = userID;
        $scope.submitPost = function (postText) {
            var ob = { PostDetails: postText, Time: new Date().toUTCString(), User_Id: id };
            console.log(ob);
            $http.post(host + "SavePost", ob).then(function (response) {
                $scope.postText = "";
                console.log(response);
                $http.get(host + "GetAllPosts").then(function (response) {
                    $scope.allPosts = response.data;
                });
            });
        }
        $http.get(host + "GetAllPosts").then(function (response) {
            $scope.allPosts = response.data;
        });


    }).controller("ProfileController", function ($scope,$http) {
        id = userID;
        $http.get(host + "GetUserById?stId=" + id).then(function (response) {
            $scope.user = response.data;
        });
       
    })