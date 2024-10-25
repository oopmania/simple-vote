using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimpleVote.Models;

namespace SimpleVote.Services;

public class VotingService
{
    private readonly List<Item> _items;
    private readonly Dictionary<string, int> _history;
    private readonly Random _random = new Random();

    public VotingService()
    {
        _items = new List<Item>
        {
            new Item { Id = 1, Name = "Apple" },
            new Item { Id = 2, Name = "Grape" },
            new Item { Id = 3, Name = "Banana" },
        };

        _history = new Dictionary<string, int>();
    }

    public List<Item> Items => _items;

    public bool Vote(int promoteId, string accessIp)
    {
        var promoteItem = _items.FirstOrDefault(x => x.Id == promoteId);

        if (promoteItem is null) return false;

        if (_history.TryGetValue(accessIp, out int demoteId) && demoteId != promoteId)
        {
            var demoteItem = _items.FirstOrDefault(x => x.Id == demoteId);

            if (demoteItem is not null && demoteItem.Votes > 0)
            {
                demoteItem.Votes--;
            }
        }

        promoteItem.Votes++;
        _history[accessIp] = promoteId;

        return true;
    }
}