import jwt from "jwt-decode";
import moment from "moment";
export default {
	// called when the user attempts to log in
	login: ({ username, password }) => {
		const request = new Request(
			"http://localhost:5000/api/v1/AdminAuthentication/generate_token",
			{
				method: "POST",
				body: JSON.stringify({ username, password }),
				headers: new Headers({ "Content-Type": "application/json" }),
			}
		);
		return fetch(request)
			.then((response) => {
				if (response.status < 200 || response.status >= 300) {
					throw new Error(response.statusText);
				}
				return response.json();
			})
			.then((tokenResponse) => {
				if (!tokenResponse.succeed)
					throw new Error(tokenResponse.error);
				localStorage.setItem("token", tokenResponse.data);
			});
	},
	// called when the user clicks on the logout button
	logout: () => {
		localStorage.removeItem("token");
		return Promise.resolve();
	},
	// called when the API returns an error
	checkError: ({ status }) => {
		if (status === 401 || status === 403) {
			localStorage.removeItem("token");
			return Promise.reject();
		}
		return Promise.resolve();
	},
	// called when the user navigates to a new location, to check for authentication
	checkAuth: () => {
		var token = localStorage.getItem("token");
		if (!token) return Promise.reject();
		var claims = token == null ? {} : jwt(token);
		var diff = claims.exp - moment(Math.floor(Date.now() / 1000));
		if (diff < 0) return Promise.reject();
		return Promise.resolve();
	},
	// called when the user navigates to a new location, to check for permissions / roles
	getPermissions: () => Promise.resolve(),
};
