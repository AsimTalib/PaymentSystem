import { useEffect, useState } from 'react';
import './App.css';
import { IPayment } from './interfaces/IPayment';
import { getAllPayments } from './services/paymentService';

interface Forecast {
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

function App() {
    //use state used like a database - for the life of the page
    const [forecasts, setForecasts] = useState<Forecast[]>();
    const [payments, setPayments] = useState<IPayment[]>();

    useEffect(() => {
        populateWeatherData();
    }, []);

    //always runnig 
    useEffect(() => {
        const fetchdata = async () =>
        {
            const result = await getAllPayments();
            setPayments(result);

        };
    }, []);

    const contents = forecasts === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
            </thead>
            <tbody>
                {forecasts.map(forecast =>
                    <tr key={forecast.date}>
                        <td>{forecast.date}</td>
                        <td>{forecast.temperatureC}</td>
                        <td>{forecast.temperatureF}</td>
                        <td>{forecast.summary}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    const paymentContent = payments === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Money Reason</th>
                    <th>Amount</th>
                </tr>
            </thead>
            <tbody>
                {payments.map(payment =>
                    <tr key={payment.firstName}>
                        <td>{payment.lastName}</td>
                        <td>{payment.moneyReason}</td>
                        <td>{payment.paymentAmount}</td>
                        
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tabelLabel">4</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
            {paymentContent }
        </div>
    );

    async function populateWeatherData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        setForecasts(data);
    }
}

export default App;