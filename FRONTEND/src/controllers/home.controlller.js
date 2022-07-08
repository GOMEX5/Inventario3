const {render} = require('ejs');

exports.home = (req, res) => {
    res.render('home',{
        title: 'Inventario'
    })
}