const { render } = require('ejs');
const axios = require('axios');

exports.listarDiag = (req, res) => {
    async function getDiag() {
        try {
            const response = await axios.get('http://localhost:5001/api/Diagnostico');
            // console.log(response.data);
            var data = response.data;
            if (req.session.loggedin) {
                res.render('diagnosticoPc/tabDiag', {
                    titulo: 'Rep',
                    data,
                    login: true,
                    name: req.session.name
                })
            } else {
                // res.redirect('/login');
                res.render('diagnosticoPc/tabDiag', {
                    data,
                    login: true,
                    name: req.session.name
                })
            }
        } catch (error) {
            console.error(error);
        }
    }
    getDiag();
}

exports.createDiag = (req, res) => {
    res.render('diagnosticoPc/CreateDiag', {
        title: 'Inventario'
    })
}

exports.addDiag = (req, res) => {
    const diag = req.body;
    axios({
        method: 'post',
        url: "http://localhost:5001/api/Diagnostico",
        data: {
            Pc: diag.Pc,
            detalle: diag.detalle,
            estado: diag.estado,
            soluccion_asignada: diag.soluccion_asignada,
        }
    });
    // console.log(user);
    res.redirect('/diag');
}

exports.deleteDiag = (req, res) => {
    const { id } = req.params;
    axios.delete("http://localhost:5001/api/Diagnostico/" + id)
        .then(response => {
            // console.log(response);
        })
        .catch(e => {
            console.console.log(e);
        });
    res.redirect('/diag');
}

exports.editDiag = (req, res) => {
    const { id } = req.params;
    axios.get("http://localhost:5001/api/rep/" + id)
        .then(response => {
            data = response.data;
            // console.log(data);
            res.render('diagnosticoPc/UpdateDiag', {
                data
            });
        })
        .catch(e => {
            console.console.log(e);
        });
}

exports.updateDiag = (req, res) => {
    const { id } = req.params;
    const rep = req.body;
    axios.put("http://localhost:5001/api/Diagnostico/" + id, rep)
        .then(response => {
            // console.log(response.data);
            res.render('diagnosticoPc/UpdateDiag', {
                data
            });
        })
        .catch(err => {
            console.log(err);
        });
}