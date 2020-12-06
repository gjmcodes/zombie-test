export class OperationResult {
    success: boolean;
    message: string;
    extraMessages: string[];
    data: any;

    constructor(success: boolean,
        message: string,
        extraMessages: string[],
        data: any) {
        this.success = success;
        this.message = message;
        this.extraMessages = extraMessages;
        this.data = data;
    }
}