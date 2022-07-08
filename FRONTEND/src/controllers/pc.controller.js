const { render } = require('ejs');
const axios = require('axios');

exports.listarPc = (req, res) => {
    async function getPc() {
        try {
            const response = await axios.get('http://localhost:5001/api/Pc');
            // console.log(response.data);
            var data = response.data;
            console.log(data);
            if (req.session.loggedin) {
                res.render('pc/tabPc', {
                    titulo: 'Pc',
                    data,
                    login: true,
                    name: req.session.name
                })
            } else {
                // res.redirect('/login');
                res.render('pc/tabPc', {
                    data,
                    login: true,
                    name: req.session.name
                })
            }
        } catch (error) {
            console.error(error);
        }
    }
    getPc();
}

exports.createPc = (req, res) => {
    res.render('pc/CreatePc', {
        title: 'Inventario'
    })
}

exports.addPc = (req, res) => {
    const pc = req.body;
    axios({
        method: 'post',
        url: "http://localhost:5001/api/Pc",
        data: {
            num_pc: lab.numPc,
            Estado: user.estado,
        }
    });
    // console.log(user);
    res.redirect('/pc');
}

exports.deletePc = (req, res) => {
    const { id } = req.params;
    axios.delete("http://localhost:5001/api/Pc/" + id)
        .then(response => {
            // console.log(response);
        })
        .catch(e => {
            console.console.log(e);
        });
    res.redirect('/pc');
}

exports.editPc = (req, res) => {
    const { id } = req.params;
    axios.get("http://localhost:5001/api/Pc/" + id)
        .then(response => {
            data = response.data;
            // console.log(data);
            res.render('pc/UpdatePc', {
                data
            });
        })
        .catch(e => {
            console.console.log(e);
        });
}

exports.updatePc = (req, res) => {
    const { id } = req.params;
    const pc = req.body;
    axios.put("http://localhost:5001/api/pc/" + id, pc)
        .then(response => {
            // console.log(response.data);
            res.render('pc/UpdatePc', {
                data
            });
        })
        .catch(err => {
            console.log(err);
        });
}