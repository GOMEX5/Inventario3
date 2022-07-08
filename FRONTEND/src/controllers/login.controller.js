const { render } = require('ejs');
const express = require('express')
const bcryptjs = require('bcryptjs');
const axios = require('axios');

exports.login = (req, res) => {
    res.render('login', {
        title: 'Inventario'
    })
}

exports.logiar = async(req, res) => {
    const user = req.body.user;
    const pass = req.body.pass;
    let passwordHaash = bcryptjs.hash(pass, 8);
    async function getUser() {
        try {
            const response = await axios.get('http://localhost:5001/api/usuario');
            var data = response.data;
            console.log("Yes");
        } catch (error) {
            console.error(error);
        }
    }
    getUser();
}

exports.logout = (req, res) => {
    req.session.destroy(() => {
        res.redirect('/')
    })
}

// if (user) {
//     const response = await axios.get('http://localhost:5001/api/usuario');
//     // console.log(response.data);
//     var data = response.data;
//     for (let i = 0; i < data.length; i++) {
//         const e = data[i];
//         if (e.nombre === user) {
//             console.log('si')
//         }
//     }
// } else {
//     res.render('login', {
//         alert: true,
//         alertTitle: "Advertencia",
//         alertMessage: "Por favor ingrese un usuario y/o password",
//         alertIcon: 'warning',
//         showConfirmButton: true,
//         timer: false,
//         ruta: 'login',
//         title: 'INVENTARIO'
//     })
// }i