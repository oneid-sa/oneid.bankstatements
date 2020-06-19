using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplifi.BankStatementsAPIDemo.models
{
	public enum BankstatementSimpleRequestStatus
	{
		Received,
		Processing,
		RequestSent,
		BankLoginSuccesfull,
		StatementReady,
		StatementRetreived,
		CancelledByClient,
		CancelledByInstitution
	}

	public class BankStatementSimpleRequest : BaseClass
	{





		public string RequesterUniqueReference
		{
			get;
			set;
		}

		public string RequesterName
		{
			get;
			set;
		}

		public string RequesterSurname
		{
			get;
			set;
		}

		public string RequesterContactTelNumber
		{
			get;
			set;
		}
		public string RequesterContactEmail
		{
			get;
			set;
		}

		public string ClientName
		{
			get;
			set;
		}

		public string ClientSurname
		{
			get;
			set;
		}
		public string ClientUniqueIdentifier
		{
			get;
			set;
		}
		public string ClientTelNumber
		{
			get;
			set;
		}
		public string ClientEmail
		{
			get;
			set;
		}
		public string BankStatementReason
		{
			get;
			set;
		}

	}
		
	}
