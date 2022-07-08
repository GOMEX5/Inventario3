const { render } = require('ejs');
const axios = require('axios');

exports.listarComp = (req, res) => {
    async function getComp() {
        try {
            const response = await axios.get('http://localhost:5001/api/Componentes');
            // console.log(response.data);
            var data = response.data;
            if (req.session.loggedin) {
                res.render('componentes/tabComp', {
                    titulo: 'Comp',
                    data,
                    login: true,
                    name: req.session.name
                })
            } else {
                // res.redirect('/login');
                res.render('componentes/tabComp', {
                    data,
                    login: true,
                    name: req.session.name
                })
            }
        } catch (error) {
            console.error(error);
        }
    }
    getComp();
}

exports.createComp = (req, res) => {
    res.render('componentes/CreateComp', {
        title: 'Inventario'
    })
}

exports.addComp = (req, res) => {
    const comp = req.body;
    axios({
        method: 'post',
        url: "http://localhost:5001/api/Componentes",
        data: {
            tipo: comp.tipo,
            marca: comp.marca,
            modelo: comp.modelo,
            estado: comp.estado,
            pc: comp.pc
        }
    });
    // console.log(user);
    res.redirect('/comp');
}

exports.deleteComp = (req, res) => {
    const { id } = req.params;
    axios.delete("http://localhost:5001/api/Componentes/" + id)
        .then(response => {
            // console.log(response);
        })
        .catch(e => {
            console.console.log(e);
        });
    res.redirect('/comp');
}

exports.editComp = (req, res) => {
    const { id } = req.params;
    axios.get("http://localhost:5001/api/Componentes/" + id)
        .then(response => {
            data = response.data;
            // console.log(data);
            res.render('componentes/UpdateComp', {
                data
            });
        })
        .catch(e => {
            console.console.log(e);
        });
}

exports.updateComp = (req, res) => {
    const { id } = req.params;
    const comp = req.body;
    axios.put("http://localhost:5001/api/Componentes/" + id, comp)
        .then(response => {
            // console.log(response.data);
            res.render('componentes/UpdateComp', {
                data
            });
        })
        .catch(err => {
            console.log(err);
        });
}