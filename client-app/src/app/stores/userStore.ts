import { makeAutoObservable } from "mobx";
import agent from "../api/agent";
import { IUser, IUserFormValues } from "../models/user";

export default class UserStore {
    user: IUser | null = null;

    constructor() {
        makeAutoObservable(this)
    }

    get isLoggedIn() {
        return !!this.user;
    }

    login = async (creds: IUserFormValues) => {
        try {
            const user = await agent.Account.login(creds);
            console.log(user);
        } catch (error) {
            throw error;
        }
    }
}