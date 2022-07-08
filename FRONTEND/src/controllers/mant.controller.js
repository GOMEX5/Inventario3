const { render } = require('ejs');
const axios = require('axios');

exports.listarMant = (req, res) => {
    async function getMant() {
        try {
            const response = await axios.get('http://localhost:5001/api/Mantenimiento');
            // console.log(response.data);
            var data = response.data;
            if (req.session.loggedin) {
                res.render('mantenimiento/tabMant', {
                    titulo: 'mant',
                    data,
                    login: true,
                    name: req.session.name
                })
            } else {
                // res.redirect('/login');
                res.render('mantenimiento/tabMant', {
                    data,
                    login: true,
                    name: req.session.name
                })
            }
        } catch (error) {
            console.error(error);
        }
    }
    getMant();
}

exports.createMant = (req, res) => {
    res.render('mantenimiento/CreateMant', {
        title: 'Inventario'
    })
}

exports.addMant = (req, res) => {
    const mant = req.body;
    axios({
        method: 'post',
        url: "http://localhost:5001/api/Mantenimiento",
        data: {
            num_pc: lab.numPc,
            Estado: user.estado,
        }
    });
    // console.log(user);
    res.redirect('/mant');
}

exports.deleteMant = (req, res) => {
    const { id } = req.params;
    axios.delete("http://localhost:5001/api/manteniemientos/" + id)
        .then(response => {
            // console.log(response);
        })
        .catch(e => {
            console.console.log(e);
        });
    res.redirect('/mant');
}

exports.editMant = (req, res) => {
    const { id } = req.params;
    axios.get("http://localhost:5001/api/Mantenimiento/" + id)
        .then(response => {
            data = response.data;
            // console.log(data);
            res.render('mantenimiento/UpdateMant', {
                data
            });
        })
        .catch(e => {
            console.console.log(e);
        });
}

exports.updateMant = (req, res) => {
    const { id } = req.params;
    const mant = req.body;
    axios.put("http://localhost:5001/api/Mantenimiento/" + id, mant)
        .then(response => {
            // console.log(response.data);
            res.render('mantenimiento/UpdateMant', {
                data
            });
        })
        .catch(err => {
            console.log(err);
        });
}