import React, { useEffect, useState } from 'react';
import { IPayment } from '../interfaces/IPayment';
import { getAllPayments } from '../services/paymentService';
import { DataGrid, GridColDef } from '@mui/x-data-grid';

function Payment() {
    const [payments, setPayments] = useState<IPayment[]>();

    //always runnig - hook is always refreshed
    useEffect(() => {

        //assign the method
        const fetchdata = async () => {
            const result = await getAllPayments();
            setPayments(result);

        };

        //call the method 
        fetchdata();
    }, []);



    const columns: GridColDef[] = [

        { field: 'firstName', headerName: 'First Name', width: 150 },
        { field: 'lastName', headerName: 'Last Name', width: 150 },
        { field: 'address', headerName: 'Address', width: 200 },
        { field: 'postCode', headerName: 'Post Code', width: 100 },
        { field: 'phoneNumber', headerName: 'Phone Number', width: 150 },
        { field: 'email', headerName: 'Email', width: 200 },
        { field: 'paymentTypeId', headerName: 'Payment Type ID', width: 150 },
        { field: 'moneyReasonId', headerName: 'Money Reason ID', width: 150 },
        { field: 'moneyReason', headerName: 'Money Reason', width: 200 },
        { field: 'paymentAmount', headerName: 'Payment Amount', width: 150 },
        { field: 'extraDetails', headerName: 'Extra Details', width: 200 },
        { field: 'referenceNumber', headerName: 'Reference Number', width: 200 },
        { field: 'paymentStatus', headerName: 'Payment Status', width: 150 },
        { field: 'paymentStatusId', headerName: 'Payment Status ID', width: 150 },
    
    ];


    function getRowId(row) {
        return row.referenceNumber;
    }

    const paymentContent = payments === undefined
        ? <p><em>Loading...  for more details.</em></p>
        : <div style={{ height: 400, width: '100%' }}>
            <DataGrid
                rows={payments}
                columns={columns}
                getRowId={getRowId}
                initialState={{
                    pagination: {
                        paginationModel: { page: 0, pageSize: 5 },
                    },
                }}
                pageSizeOptions={[5, 10]}
                checkboxSelection

               
            />
        </div>

    return (
        <div>
            {paymentContent}
        </div>
     
      
  );
}

export default Payment;