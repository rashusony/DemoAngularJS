/// <reference path="script.js" />

myApp.filter("Gender", function () {
    return function (gender) {
        switch (gender) {
            case "male":
                return 1;
            case "female":
                return 2;

        }

    }
});