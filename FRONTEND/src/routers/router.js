const { Router } = require('express');
const router = Router();

//router home and login
const HomeControllers = require('../controllers/home.controlller');
const LoginControllers = require('../controllers/login.controller');
router.get('/', HomeControllers.home);
router.get('/login', LoginControllers.login);
router.get('/logiar', LoginControllers.logiar);

//router user
const UserControllers = require('../controllers/user.controller');

router.get('/createUser', UserControllers.createUser);
router.get('/user', UserControllers.listarUser);
router.post('/user', UserControllers.listarUser);
router.post('/addUser', UserControllers.addUser);
router.get('/deleteUser/:id', UserControllers.deleteUser);
router.get('/editUser/:id', UserControllers.editUser);
router.post('/updateUser/:id', UserControllers.updateUser);

//router componentes
const CompControllers = require('../controllers/comp.controller');

router.get('/createComp', CompControllers.createComp);
router.get('/comp', CompControllers.listarComp);
router.post('/comp', CompControllers.listarComp);
router.post('/addComp', CompControllers.addComp);
router.get('/deleteComp/:id', CompControllers.deleteComp);
router.get('/editComp/:id', CompControllers.editComp);
router.post('/updateComp/:id', CompControllers.updateComp);

//router pc
const PcControllers = require('../controllers/pc.controller');

router.get('/createPc', PcControllers.createPc);
router.get('/pc', PcControllers.listarPc);
router.post('/pc', PcControllers.listarPc);
router.post('/addPc', PcControllers.addPc);
router.get('/deletePc/:id', PcControllers.deletePc);
router.get('/editPc/:id', PcControllers.editPc);
router.post('/updatePc/:id', PcControllers.updatePc);

//router lab
const LabControllers = require('../controllers/lab.controller');

router.get('/createLab', LabControllers.createLab);
router.get('/lab', LabControllers.listarLab);
router.post('/lab', LabControllers.listarLab);
router.post('/addLab', LabControllers.addLab);
router.get('/deleteLab/:id', LabControllers.deleteLab);
router.get('/editLab/:id', LabControllers.editLab);
router.post('/updateLab/:id', LabControllers.updateLab);

//router herramientas
const HerControllers = require('../controllers/her.controllers');

router.get('/createHer', HerControllers.createHer);
router.get('/her', HerControllers.listarHer);
router.post('/her', HerControllers.listarHer);
router.post('/addHer', HerControllers.addHer);
router.get('/deleteHer/:id', HerControllers.deleteHer);
router.get('/editHer/:id', HerControllers.editHer);
router.post('/updateHer/:id', HerControllers.updateHer);

//router diagnosticoPc
const DiagControllers = require('../controllers/diag.controller');

router.get('/createDiag', DiagControllers.createDiag);
router.get('/diag', DiagControllers.listarDiag);
router.post('/diag', DiagControllers.listarDiag);
router.post('/addDiag', DiagControllers.addDiag);
router.get('/deleteDiag/:id', DiagControllers.deleteDiag);
router.get('/editDiag/:id', DiagControllers.editDiag);
router.post('/updateDiag/:id', DiagControllers.updateDiag);

//router repuestos
const RepControllers = require('../controllers/rep.controller');

router.get('/createRep', RepControllers.createRep);
router.get('/rep', RepControllers.listarRep);
router.post('/rep', RepControllers.listarRep);
router.post('/addRep', RepControllers.addRep);
router.get('/deleteRep/:id', RepControllers.deleteRep);
router.get('/editRep/:id', RepControllers.editRep);
router.post('/updateRep/:id', RepControllers.updateRep);

//router mantenimiento
const MantControllers = require('../controllers/mant.controller');

router.get('/createMant', MantControllers.createMant);
router.get('/mant', MantControllers.listarMant);
router.post('/mant', MantControllers.listarMant);
router.post('/addMant', MantControllers.addMant);
router.get('/deleteMant/:id', MantControllers.deleteMant);
router.get('/editMant/:id', MantControllers.editMant);
router.post('/updateMant/:id', MantControllers.updateMant);
module.exports = router;