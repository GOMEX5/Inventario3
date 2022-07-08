const { render } = require('ejs');
const axios = require('axios');

exports.listarRep = (req, res) => {
    async function getRep() {
        try {
            const response = await axios.get('http://localhost:5001/api/Repuestos');
            // console.log(response.data);
            var data = response.data;
            if (req.session.loggedin) {
                res.render('repuestos/tabRep', {
                    titulo: 'Rep',
                    data,
                    login: true,
                    name: req.session.name
                })
            } else {
                // res.redirect('/login');
                res.render('repuestos/tabRep', {
                    data,
                    login: true,
                    name: req.session.name
                })
            }
        } catch (error) {
            console.error(error);
        }
    }
    getRep();
}

exports.createRep = (req, res) => {
    res.render('repuestos/CreateRep', {
        title: 'Inventario'
    })
}

exports.addRep = (req, res) => {
    const rep = req.body;
    axios({
        method: 'post',
        url: "http://localhost:5001/api/Repuestos",
        data: {
            nombre: rep.nombre,
            serie: rep.serie,
            estado: rep.estado,
            cantidad: rep.cantidad,
            info: rep.info

        }
    });
    // console.log(user);
    res.redirect('/rep');
}

exports.deleteRep = (req, res) => {
    const { id } = req.params;
    axios.delete("http://localhost:5001/api/Repuestos/" + id)
        .then(response => {
            // console.log(response);
        })
        .catch(e => {
            console.console.log(e);
        });
    res.redirect('/rep');
}

exports.editRep = (req, res) => {
    const { id } = req.params;
    axios.get("http://localhost:5001/api/rep/" + id)
        .then(response => {
            data = response.data;
            // console.log(data);
            res.render('repuestos/UpdateRep', {
                data
            });
        })
        .catch(e => {
            console.console.log(e);
        });
}

exports.updateRep = (req, res) => {
    const { id } = req.params;
    const rep = req.body;
    axios.put("http://localhost:5001/api/Repuestos/" + id, rep)
        .then(response => {
            // console.log(response.data);
            res.render('repuestos/UpdateRep', {
                data
            });
        })
        .catch(err => {
            console.log(err);
        });
}