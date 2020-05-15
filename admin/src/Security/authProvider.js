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
				return new Promise((resolve, reject) => {
					if (response.status === 200) {
						return resolve(response.json());
					} else {
						return reject(response.text());
					}
				});
			})
			.then(({ token }) => {
				localStorage.setItem("token", token);
				return Promise.resolve("token");
			})
			.catch(async (err) => {
				var text = await err;
				return Promise.reject(text);
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
		return localStorage.getItem("token")
			? Promise.resolve()
			: Promise.reject();
	},
	// called when the user navigates to a new location, to check for permissions / roles
	getPermissions: () => Promise.resolve(),
};
