﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace todoCli
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="testDb")]
	public partial class TodoDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTodo(Todo instance);
    partial void UpdateTodo(Todo instance);
    partial void DeleteTodo(Todo instance);
    #endregion
		
		public TodoDataContext() : 
				base(global::todoCli.Properties.Settings.Default.testDbConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public TodoDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TodoDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TodoDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TodoDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Todo> Todos
		{
			get
			{
				return this.GetTable<Todo>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Todos")]
	public partial class Todo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _todoId;
		
		private string _task;
		
		private System.Nullable<byte> _status;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OntodoIdChanging(int value);
    partial void OntodoIdChanged();
    partial void OntaskChanging(string value);
    partial void OntaskChanged();
    partial void OnstatusChanging(System.Nullable<byte> value);
    partial void OnstatusChanged();
    #endregion
		
		public Todo()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_todoId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int todoId
		{
			get
			{
				return this._todoId;
			}
			set
			{
				if ((this._todoId != value))
				{
					this.OntodoIdChanging(value);
					this.SendPropertyChanging();
					this._todoId = value;
					this.SendPropertyChanged("todoId");
					this.OntodoIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_task", DbType="VarChar(255)")]
		public string task
		{
			get
			{
				return this._task;
			}
			set
			{
				if ((this._task != value))
				{
					this.OntaskChanging(value);
					this.SendPropertyChanging();
					this._task = value;
					this.SendPropertyChanged("task");
					this.OntaskChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_status", DbType="TinyInt")]
		public System.Nullable<byte> status
		{
			get
			{
				return this._status;
			}
			set
			{
				if ((this._status != value))
				{
					this.OnstatusChanging(value);
					this.SendPropertyChanging();
					this._status = value;
					this.SendPropertyChanged("status");
					this.OnstatusChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
