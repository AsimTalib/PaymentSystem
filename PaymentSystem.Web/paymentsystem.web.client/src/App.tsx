import './App.css';
import Home from './pages/home';
import Login from './pages/login';
import { Routes,Route, BrowserRouter } from 'react-router-dom';


function App() {
    
    return (
        
            //<Routes>
            //    <Route path="/" element={<Home />} />
            //        <Route path="/login" element={<Login />} />
        // </Routes>
            <Login/>
       
           
        
    );
}

export default App;