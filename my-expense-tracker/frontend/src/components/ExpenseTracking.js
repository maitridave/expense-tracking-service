import React, { useState, useEffect } from 'react';
import ExpenseService from '../services/ExpenseService';

const ExpenseTracking = () => {
    const [expenses, setExpenses] = useState([]);
    const [amount, setAmount] = useState('');
    const [description, setDescription] = useState('');
    const [categoryId, setCategoryId] = useState('');
    const [categories, setCategories] = useState([]);

    useEffect(() => {
        fetchExpenses();
        fetchCategories();
    }, []);

    const fetchExpenses = async () => {
        const response = await ExpenseService.fetchExpenses();
        setExpenses(response.data);
    };

    const fetchCategories = async () => {
        const response = await ExpenseService.fetchExpenseCategories();
        setCategories(response.data);
    };

    const handleAddExpense = async (e) => {
        e.preventDefault();
        await ExpenseService.createExpense({ amount, description, categoryId });
        fetchExpenses();
        setAmount('');
        setDescription('');
        setCategoryId('');
    };

    return (
        <div>
            <h2>Expense Tracking</h2>
            <form onSubmit={handleAddExpense}>
                <input
                    type="number"
                    placeholder="Amount"
                    value={amount}
                    onChange={(e) => setAmount(e.target.value)}
                    required
                />
                <input
                    type="text"
                    placeholder="Description"
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    required
                />
                <select
                    value={categoryId}
                    onChange={(e) => setCategoryId(e.target.value)}
                    required
                >
                    <option value="">Select Category</option>
                    {categories.map((category) => (
                        <option key={category.id} value={category.id}>
                            {category.name}
                        </option>
                    ))}
                </select>
                <button type="submit">Add Expense</button>
            </form>
            <h3>Expenses List</h3>
            <ul>
                {expenses.map((expense) => (
                    <li key={expense.id}>
                        {expense.description}: ${expense.amount} on {new Date(expense.date).toLocaleDateString()}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default ExpenseTracking;