
// Reference the npm packages so that they're bundled into the build
// Content/components/expose-components.js

import React from 'react';
import ReactDOM from 'react-dom';
import ReactDOMServer from 'react-dom/server';

import RootComponent from './js/components/home.jsx';

// any css-in-js or other libraries you want to use server-side
import { ServerStyleSheet } from 'styled-components';
import { renderStylesToString } from 'emotion-server';
import Helmet from 'react-helmet';

global.React = React;
global.ReactDOM = ReactDOM;
global.ReactDOMServer = ReactDOMServer;

global.Styled = { ServerStyleSheet };
global.Helmet = Helmet;

global.Components = { RootComponent };
import 'jquery';
import 'jquery-validation';
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import '../Content/Site.css';

// This willchange the application name in the navbar
$(document).ready(function () {
    $('.navbar-brand').text('test2');
});