export interface IPayment {

    firstName: string;
    lastName: string;
    address: string;
    postCode: string;
    phoneNumber: string;
    email: string;
    paymentTypeId: number;
    moneyReasonId: number;
    moneyReason: string;
    paymentAmount: number;
    extraDetails: string;
    referenceNumber: string;
    paymentStatus: string;
    paymentStatusId: number;

}