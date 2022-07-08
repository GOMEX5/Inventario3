const { render } = require('ejs');
const axios = require('axios');

exports.listarLab = (req, res) => {
    async function getLab() {
        try {
            const response = await axios.get('http://localhost:5001/api/laboratorio');
            // console.log(response.data);
            var data = response.data;
            console.log(data);
            if (req.session.loggedin) {
                res.render('lab/tabLab', {
                    titulo: 'Lab',
                    data,
                    login: true,
                    name: req.session.name
                })
            } else {
                // res.redirect('/login');
                res.render('lab/tabLab', {
                    data,
                    login: true,
                    name: req.session.name
                })
            }
        } catch (error) {
            console.error(error);
        }
    }
    getLab();
}

exports.createLab = (req, res) => {
    res.render('lab/CreateLab', {
        title: 'Inventario'
    })
}

exports.addLab = (req, res) => {
    const lab = req.body;
    axios({
        method: 'post',
        url: "http://localhost:5001/api/lab",
        data: {
            num_pc: lab.numPc,
            Estado: user.estado,
        }
    });
    // console.log(user);
    res.redirect('/lab');
}

exports.deleteLab = (req, res) => {
    const { id } = req.params;
    axios.delete("http://localhost:5001/api/lab/" + id)
        .then(response => {
            // console.log(response);
        })
        .catch(e => {
            console.console.log(e);
        });
    res.redirect('/user');
}

exports.editLab = (req, res) => {
    const { id } = req.params;
    axios.get("http://localhost:5001/api/lab/" + id)
        .then(response => {
            data = response.data;
            // console.log(data);
            res.render('lab/UpdateLab', {
                data
            });
        })
        .catch(e => {
            console.console.log(e);
        });
}

exports.updateLab = (req, res) => {
    const { id } = req.params;
    const lab = req.body;
    axios.put("http://localhost:5001/api/lab/" + id, lab)
        .then(response => {
            // console.log(response.data);
            res.render('lab/UpdateLab', {
                data
            });
        })
        .catch(err => {
            console.log(err);
        });
}