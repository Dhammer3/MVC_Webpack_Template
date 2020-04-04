// Reference the npm packages so that they're bundled into the build
import 'jquery';
import 'jquery-validation';
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import '../Content/Site.css';

// This willchange the application name in the navbar
$(document).ready(function () {
    $('.navbar-brand').text('test2');
});