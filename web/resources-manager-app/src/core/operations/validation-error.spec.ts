import { ValidationError } from './validation-error';

describe('ValidationError', () => {
  it('should create an instance', () => {
    expect(new ValidationError()).toBeTruthy();
  });
});
