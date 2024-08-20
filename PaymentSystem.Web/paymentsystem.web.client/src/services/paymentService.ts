import { IPayment } from "../interfaces/IPayment";

export const getAllPayments = async (): Promise<IPayment[]> => {

    let url = 'payment';
    const response = await fetch(url);

    if (!response.ok) {
        throw new Error("Data is null");
    }
    const data = await response.json();
    return data;
} 