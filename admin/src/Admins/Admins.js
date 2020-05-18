import React from "react";
import { useMediaQuery } from "@material-ui/core";
import {
	List,
	SimpleList,
	Datagrid,
	TextField,
	Edit,
	SimpleForm,
	PasswordInput,
	TextInput,
	BooleanField,
	BooleanInput,
	Create,
	Filter,
	required,
	EditButton,
} from "react-admin";

const AdminsFilter = (props) => (
	<Filter {...props}>
		<TextInput label="Search" source="username" alwaysOn />
		<BooleanInput source="isActive" defaultValue={true} />
	</Filter>
);

export const AdminsList = (props) => {
	const isSmall = useMediaQuery((theme) => theme.breakpoints.down("sm"));
	return (
		<List filters={<AdminsFilter />} {...props}>
			{isSmall ? (
				<SimpleList
					primaryText={(record) => record.username}
					secondaryText={(record) => {
						return record.isActive ? "active" : "inactive";
					}}
				/>
			) : (
				<Datagrid>
					<TextField source="username" />
					<BooleanField source="isActive" />
					<EditButton />
				</Datagrid>
			)}
		</List>
	);
};

const AdminsTitle = ({ record }) => {
	return <span>Edit {record ? `"${record.username}"` : ""}</span>;
};

export const AdminsEdit = (props) => (
	<Edit title={<AdminsTitle />} {...props}>
		<SimpleForm>
			<TextInput source="username" validate={required()} />
			<BooleanInput source="isActive" />
		</SimpleForm>
	</Edit>
);

export const AdminsCreate = (props) => (
	<Create {...props}>
		<SimpleForm>
			<TextInput source="username" validate={required()} />
			<PasswordInput source="password" validate={required()} />
			<BooleanInput source="isActive" defaultValue={true} />
		</SimpleForm>
	</Create>
);
