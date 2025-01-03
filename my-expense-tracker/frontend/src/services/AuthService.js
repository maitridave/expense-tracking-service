export default class AuthService {
    constructor(apiUrl) {
        this.apiUrl = apiUrl;
    }

    async login(username, password) {
        const response = await fetch(`${this.apiUrl}/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ username, password }),
        });

        if (!response.ok) {
            throw new Error('Login failed');
        }

        const data = await response.json();
        localStorage.setItem('token', data.token);
        return data;
    }

    logout() {
        localStorage.removeItem('token');
    }

    isAuthenticated() {
        return localStorage.getItem('token') !== null;
    }

    async register(username, password, email) {
        const response = await fetch(`${this.apiUrl}/register`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ username, password, email }),
        });

        if (!response.ok) {
            throw new Error('Registration failed');
        }

        return await response.json();
    }
}