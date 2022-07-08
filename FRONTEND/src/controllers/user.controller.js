const { render } = require('ejs');
const axios = require('axios');
const bcryptjs = require('bcryptjs');

// var generador = () => {
//     return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
//         var r = Math.random() * 16 | 0,
//             v = c == 'x' ? r : (r & 0x3 | 0x8);
//         return v.toString(16);
//     });
// }

// console.log(generador());


exports.listarUser = (req, res) => {
    async function getUser() {
        try {
            const response = await axios.get('http://localhost:5001/api/usuario');
            // console.log(response.data);
            var data = response.data;
            if (req.session.loggedin) {
                res.render('user/tabUser', {
                    data,
                    login: true,
                    name: req.session.name
                })
            } else {
                // res.redirect('/login');
                res.render('user/tabUser', {
                    data,
                    login: true,
                    name: req.session.name
                })
            }
        } catch (error) {
            console.error(error);
        }
    }
    getUser();
}

exports.createUser = (req, res) => {
    res.render('user/CreateUser', {
        title: 'Inventario'
    })
}

exports.addUser = (req, res) => {
    const user = req.body;
    let pass = bcryptjs.hash(user.password, 8);
    axios({
        method: 'post',
        url: "http://localhost:5001/api/usuario",
        data: {
            nombre: user.nombre,
            apellido: user.apellido,
            cargo: user.cargo,
            telefono: user.telefono,
            direccion: user.direccion,
            correo: user.email,
            password: user.password
        }
    });
    // console.log(user);
    res.redirect('/user');
}

exports.deleteUser = (req, res) => {
    const { id } = req.params;
    axios.delete("http://localhost:5001/api/usuario/" + id)
        .then(response => {
            // console.log(response);
        })
        .catch(e => {
            console.console.log(e);
        });
    res.redirect('/user');
}

exports.editUser = (req, res) => {
    const { id } = req.params;
    axios.get("http://localhost:5001/api/usuario/" + id)
        .then(response => {
            data = response.data;
            // console.log(data);
            res.render('user/UpdateUser', {
                data
            });
        })
        .catch(e => {
            console.console.log(e);
        });
}

exports.updateUser = (req, res) => {
    const { id } = req.params;
    const user = req.body;
    axios.put("http://localhost:5001/api/usuario/" + id, user)
        .then(response => {
            // console.log(response.data);
            res.render('user/tbUser', {
                data
            });
        })
        .catch(err => {
            console.log(err);
        });
}