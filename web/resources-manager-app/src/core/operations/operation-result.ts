import { ValidationResult } from './validation-result';

export class OperationResult {
    validationResult: ValidationResult;
    hasErrors: boolean;
    data: any;

    constructor(validationResult: ValidationResult,
        hasErrors: boolean,
        data: any) {
        this.validationResult = validationResult;
        this.hasErrors = hasErrors;
        this.data = data;
    }

}