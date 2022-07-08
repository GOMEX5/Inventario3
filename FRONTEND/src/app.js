const path = require('path');
const morgan = require('morgan');
const express = require('express');
const app = express();
const session = require('express-session');

//creado seciones
app.use(session({
    secret: 'secret',
    resave: true,
    saveUninitialized: true
}));

//import routers
const routers = require('./routers/router');

//settings
app.set('port', process.env.PORT || 3000);
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'ejs');

//middlewares
app.use(morgan('dev'));
app.use(express.urlencoded({ extended: false }));
app.use(express.json());

//routers
app.use('/', routers);


//static file
app.use(express.static(path.join(__dirname, 'public')));

module.exports = app;