import './App.css';
import Home from './pages/home';
import Login from './pages/login';
import { Routes,Route } from 'react-router-dom';
import Operations from './pages/Operations';


function App() {
    
    return (
        
            <Routes>
                <Route path="/" element={<Login />} />
                <Route path="/home" element={<Home />} />
                <Route path="/operations" element={<Operations />} />
            </Routes>
        
        
    );
}

export default App;