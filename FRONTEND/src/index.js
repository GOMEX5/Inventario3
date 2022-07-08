const app = require('./app.js');

const main = async () => {
    await app.listen(app.get('port'), () =>{
        console.log('FrontEnd on port: http://localhost:'+app.get('port'));
    });
}

main();