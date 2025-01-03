import AuthService from '../services/AuthService';

describe('AuthService', () => {
    let authService;

    beforeEach(() => {
        authService = new AuthService();
    });

    test('login should return user data on successful authentication', async () => {
        const mockUser = { username: 'testuser', password: 'password' };
        const response = await authService.login(mockUser.username, mockUser.password);
        expect(response).toHaveProperty('token');
        expect(response).toHaveProperty('user');
    });

    test('login should throw an error on failed authentication', async () => {
        const mockUser = { username: 'wronguser', password: 'wrongpassword' };
        await expect(authService.login(mockUser.username, mockUser.password)).rejects.toThrow('Authentication failed');
    });

    test('logout should clear user data', () => {
        authService.logout();
        expect(authService.getCurrentUser()).toBeNull();
    });

    test('getCurrentUser should return user data if logged in', () => {
        const mockUser = { username: 'testuser', token: 'token' };
        authService.setCurrentUser(mockUser);
        expect(authService.getCurrentUser()).toEqual(mockUser);
    });

    test('getCurrentUser should return null if not logged in', () => {
        authService.logout();
        expect(authService.getCurrentUser()).toBeNull();
    });
});