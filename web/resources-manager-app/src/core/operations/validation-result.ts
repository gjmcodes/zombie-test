import { ValidationError } from './validation-error';

export class ValidationResult {
    public isValid: boolean;
    public errors: ValidationError[];
}

