
import axios from 'axios';

const API_URL = 'http://localhost:5000/api/Categories';

class CategoryService {
    getCategories() {
        return axios.get(API_URL);
    }
}

export default new CategoryService();