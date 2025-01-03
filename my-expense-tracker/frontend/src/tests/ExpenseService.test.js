import ExpenseService from '../services/ExpenseService';

describe('ExpenseService', () => {
    let expenseService;

    beforeEach(() => {
        expenseService = new ExpenseService();
    });

    test('should create an expense', async () => {
        const expenseData = {
            amount: 100,
            description: 'Test Expense',
            date: '2023-10-01',
            categoryId: 1
        };

        const response = await expenseService.createExpense(expenseData);
        expect(response).toHaveProperty('id');
        expect(response.amount).toBe(expenseData.amount);
        expect(response.description).toBe(expenseData.description);
    });

    test('should fetch all expenses', async () => {
        const expenses = await expenseService.fetchExpenses();
        expect(Array.isArray(expenses)).toBe(true);
    });
});