const { render } = require('ejs');
const axios = require('axios');

exports.listarHer = (req, res) => {
    async function getHer() {
        try {
            const response = await axios.get('http://localhost:5001/api/Herramientas');
            // console.log(response.data);
            var data = response.data;
            if (req.session.loggedin) {
                res.render('herramientas/tabHer', {
                    titulo: 'Her',
                    data,
                    login: true,
                    name: req.session.name
                })
            } else {
                // res.redirect('/login');
                res.render('herramientas/tabHer', {
                    data,
                    login: true,
                    name: req.session.name
                })
            }
        } catch (error) {
            console.error(error);
        }
    }
    getHer();
}

exports.createHer = (req, res) => {
    res.render('herramientas/CreateHer', {
        title: 'Inventario'
    })
}

exports.addHer = (req, res) => {
    const her = req.body;
    axios({
        method: 'post',
        url: "http://localhost:5001/api/Herramientass",
        data: {
            nombre: her.nombre,
            tipo: her.tipo,
            estado: her.estado,
            cantidad: her.cantidad,
            usuarios: her.usuarios,
        }
    });
    // console.log(user);
    res.redirect('/her');
}

exports.deleteHer = (req, res) => {
    const { id } = req.params;
    axios.delete("http://localhost:5001/api/Herramientass/" + id)
        .then(response => {
            // console.log(response);
        })
        .catch(e => {
            console.console.log(e);
        });
    res.redirect('/her');
}

exports.editHer = (req, res) => {
    const { id } = req.params;
    axios.get("http://localhost:5001/api/Herramientass/" + id)
        .then(response => {
            data = response.data;
            // console.log(data);
            res.render('herramientas/UpdateHer', {
                data
            });
        })
        .catch(e => {
            console.console.log(e);
        });
}

exports.updateHer = (req, res) => {
    const { id } = req.params;
    const Her = req.body;
    axios.put("http://localhost:5001/api/Herramientass/" + id, her)
        .then(response => {
            // console.log(response.data);
            res.render('herramientas/UpdateHer', {
                data
            });
        })
        .catch(err => {
            console.log(err);
        });
}
