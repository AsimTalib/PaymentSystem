export interface LoginModel {
    username: string;
    password: string;
}


export const loginUser = async (user: LoginModel): Promise<boolean> => {
    try {
        const response = await fetch("/account"

            , {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(user),


            }
        );
        if (!response.ok) {
            return false;
        } return true;
    } catch (exception) {
        console.error("Error with post log in method" + exception);
    }
    return false;
}
